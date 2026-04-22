from fastapi import FastAPI, UploadFile, File, Form
from pydantic import BaseModel
import tempfile
import shutil

from models.image_model import (
    load_image_model,
    predict_image,
    is_loaded as image_ready
)

from models.text_model import (
    load_text_model,
    is_loaded as text_ready,
    predict_text
)

from models.translate_model import (
    translate_text,
    is_ready as translate_ready,
    ensure_load
)

from services.video_service import analyze_video

print("STARTING NEW MAIN.PY")
app=FastAPI()

@app.on_event("startup")
def startup_event():
    print("Loading image model...")
    try:
        load_image_model()
        print("Image model ready")
    except Exception as e:
        print("Failed to load image model:", e)

    print("Loading text model...")
    try:
        load_text_model()
        print("Text model ready")
    except Exception as e:
        print("Failed to load text model:", e)
    print("Loading translation model...")
    try:
        ensure_load()
        print("Translation model ready")
    except Exception as e:
        print("Failed to load translation model:", e)

    print("ALL MODELS LOADED")

@app.get("/health")
def health():
    ready=image_ready() and text_ready()
    return {
        "status":"ready" if ready else "loading",
        "image":image_ready(),
        "text":text_ready(),
        #"image": True,
        #"text": True,
        "translation":translate_ready()
    }

class TextInput(BaseModel):
    text:str

@app.post("/predict/image")
async def image(file:UploadFile=File(...)):
    return await predict_image(file)


@app.post("/predict/text")
async def text(data:TextInput):
    try:
        return await predict_text(data.text)
    except Exception as e:
        print("Error in /predict/text:", e)
        return {
            "error":"Prediction failed"
        }

@app.post("/translate")
async def translate(data:TextInput):
    return await translate_text(data.text)

@app.post("/predict/video")
async def video(file:UploadFile=File(...), frame_step: int=Form(...)):
    frame_step=max(1, frame_step)
    with tempfile.NamedTemporaryFile(delete=False, suffix=".mp4") as tmp:
        shutil.copyfileobj(file.file, tmp)
        tmp_path=tmp.name
    result=analyze_video(tmp_path, frame_step)
    return {
        "ai_percentage":result
        }
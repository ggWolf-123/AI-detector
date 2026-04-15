from fastapi import FastAPI, UploadFile, File
from pydantic import BaseModel
from models.image_model import predict_image, load_image_model
from models.text_model import load_text_model, predict_text
from models.translate_model import translate_text, is_ready as translate_ready
print("STARTING NEW MAIN.PY")
app=FastAPI()

@app.get("/health")
def health():
    return {
        #"image":load_image_model.is_loaded(),
        #"text":load_text_model.is_loaded(),
        "image": True,
        "text": True,
        "translation":translate_ready()
    }

@app.post("/predict/image")
async def image(file:UploadFile=File(...)):
    return await predict_image(file)

class TextInput(BaseModel):
    text:str

@app.post("/predict/text")
async def text(data:TextInput):
    return await predict_text(data.text)

@app.post("/translate")
async def translate(data:TextInput):
    return await translate_text(data.text)
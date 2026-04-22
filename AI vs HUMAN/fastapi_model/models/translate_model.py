import torch
from transformers import MarianMTModel, MarianTokenizer
from langdetect import detect
import threading

DEVICE = torch.device("cuda" if torch.cuda.is_available() else "cpu")

MODEL_NAME = "Helsinki-NLP/opus-mt-mul-en"

_tokenizer=None
_model=None
_ready=False

def ensure_load():
    global _tokenizer, _model, _ready
    if _ready:
        return
    _tokenizer = MarianTokenizer.from_pretrained(MODEL_NAME)
    _model = MarianMTModel.from_pretrained(MODEL_NAME).to(DEVICE)
    _model.eval()
    _ready = True

def is_ready():
    return _ready

async def translate_text(text: str):
    ensure_load()  # Ensure model is loaded
    if not _ready:
        return {"error": "Model is loading, please try again later."}

    if not text or text.strip() == "":
        return {"error": "Text is empty"}
    if detect(text) == "en":
        return {"translated_text": text} # No translation needed

    inputs = _tokenizer(text, return_tensors="pt", padding=True, truncation=True).to(DEVICE)

    with torch.no_grad():
        translated = _model.generate(**inputs)

    return {
        "translated_text": _tokenizer.decode(translated[0], skip_special_tokens=True)
    }
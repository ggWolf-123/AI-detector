import torch
from transformers import MarianMTModel, MarianTokenizer
from langdetect import detect
import threading

DEVICE = torch.device("cuda" if torch.cuda.is_available() else "cpu")

MODEL_NAME = "Helsinki-NLP/opus-mt-mul-en"

_tokenizer=None
_model=None
_ready=False

def _load():
    global _tokenizer, _model, _ready
    if _ready:
        return
    _tokenizer = MarianTokenizer.from_pretrained(MODEL_NAME)
    _model = MarianMTModel.from_pretrained(MODEL_NAME).to(DEVICE)
    _model.eval()
    _ready = True


threading.Thread(target=_load, daemon=True).start()

def is_ready():
    return _ready

async def translate_text(text: str):
    if not _ready:
        return {"error": "Model is loading, please try again later."}

    if not text or text.strip() == "":
        return {"error": "Text is empty"}
    if detect(text) == "en":
        return {"translated_text": text} # No translation needed

    inputs = _tokenizer(text, return_tensors="pt", padding=True, truncation=True).to(DEVICE)
    inputs={k: v.to(DEVICE) for k,v in inputs.items()}

    with torch.no_grad():
        translated = _model.generate(**inputs)

    return {
        "translated_text": _tokenizer.decode(translated[0], skip_special_tokens=True)
    }
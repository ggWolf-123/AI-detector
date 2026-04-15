import pickle
import joblib

_model=None
_vectorizer=None

def load_text_model():
    global _model, _vectorizer
    if _model is not None and _vectorizer is not None:
        return _model, _vectorizer
    
    _model=joblib.load("assets/SVM_model.pkl")
    _vectorizer=pickle.load(open("assets/vectorizer.pkl","rb"))

def is_loaded():
    return _model is not None and _vectorizer is not None

async def predict_text(text: str):
    model, vectorizer=load_text_model()
    if not text or len(text.strip())==0:
        return {
            "error":"Text is empty"
        }
    features=_vectorizer.transform([text])
    pred=_model.predict(features)[0]
    mapped=1 if pred==0 else 0
    return {
        "result":mapped,
        "label":"AI" if mapped==1 else "HUMAN"
    }
    
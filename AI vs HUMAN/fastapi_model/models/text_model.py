
import joblib

_model=None
_vectorizer=None

def load_text_model():
    global _model, _vectorizer
    if _model is not None and _vectorizer is not None:
        return _model, _vectorizer
    
    try:
        _model=joblib.load("assets/SVM_model.pkl")
        _vectorizer=joblib.load("assets/vectorizer.pkl")
    except Exception as e:
        print("Error loading text model:", e)
        _model=None
        _vectorizer=None
        raise

    return _model, _vectorizer

def is_loaded():
    return _model is not None and _vectorizer is not None

async def predict_text(text: str):
    model, vectorizer=load_text_model()
    if not text or len(text.strip())==0:
        return {
            "error":"Text is empty"
        }
    try:
        features=vectorizer.transform([text])
        pred=model.predict(features)[0]
        mapped=1 if pred==1 else 0
        return {
            "result":mapped,
            "label":"AI" if mapped==1 else "HUMAN"
        }
    except Exception as e:
        print("Error during text prediction:", e)
        return {
            "error":"Prediction failed"
        }
    
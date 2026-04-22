import torch
import torch.nn as nn
from torchvision import transforms, models
import io
from PIL import Image
import numpy as np

DEVICE=torch.device("cuda" if torch.cuda.is_available() else "cpu")
_model=None

transform_pipeline=transforms.Compose([
    transforms.Resize((512,512)),
    transforms.ToTensor(),
    transforms.Normalize(mean=[0.485, 0.456, 0.406], std=[0.229, 0.224, 0.225])
])

def load_image_model():
    global _model
    if _model is not None:
        return _model
    
    m=models.efficientnet_b0(weights=None)
    m.classifier[1]=nn.Linear(m.classifier[1].in_features,2)
    m.load_state_dict(torch.load("assets/image_model.pth", map_location=DEVICE))
    m.to(DEVICE)
    m.eval()
    _model=m
    return _model

def is_loaded():
    return _model is not None

def predict_frame_local(frame):
    model=load_image_model()
    img=Image.fromarray(frame[...,::-1])
    img=transform_pipeline(img).unsqueeze(0).to(DEVICE)

    with torch.no_grad():
        output=model(img)
        pred=output.argmax(1).item()
    mapped=1 if pred==0 else 0
    return mapped

async def predict_image(file):
    model=load_image_model()
    img_bytes=await file.read()
    img=Image.open(io.BytesIO(img_bytes)).convert("RGB")
    img=transform_pipeline(img).unsqueeze(0).to(DEVICE)

    with torch.no_grad():
        output=model(img)
        pred=output.argmax(1).item()
        mapped=1 if pred==0 else 0
        return {
            "result":mapped,
            "label":"AI" if mapped==1 else "HUMAN"
        }
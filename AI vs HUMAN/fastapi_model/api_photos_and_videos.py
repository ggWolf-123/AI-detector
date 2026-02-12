import torch
import torch.nn as nn
from torchvision import transforms, models
import io
from PIL import Image
from fastapi import FastAPI, UploadFile, File

MODEL_PATH="model_0.9971100508165561.pth"
DEVICE=torch.device("cuda" if torch.cuda.is_available() else "cpu")
app=FastAPI()

# transformacje zdjęć
val_transforms=transforms.Compose([
    transforms.Resize((512,512)),
    transforms.ToTensor(),
    transforms.Normalize([0.485,0.456,0.406],[0.229,0.224,0.225])
])


def load_model():
	model=models.efficientnet_b0(pretrained=False)
	model.classifier[1]=nn.Linear(model.classifier[1].in_features,2)
	model.load_state_dict(torch.load(MODEL_PATH,map_location=DEVICE))
	model=model.to(DEVICE)
	model.eval()
	return model
#print("Ładowanie modelu...")
model=load_model()
#print("Model załadowany")
@app.post("/predict")
async def predict(file:UploadFile=File(...)):
	try:
		image_bytes=await file.read()
		img=Image.open(io.BytesIO(image_bytes)).convert("RGB")
		img=val_transforms(img).unsqueeze(0).to(DEVICE)

		with torch.no_grad():
			outputs=model(img)
			pred=outputs.argmax(1).item()
	
		mapped=1 if pred==0 else 0
		return{
			"result":mapped,
			"label": "AI" if mapped==1 else "HUMAN"
		}
	except Exception as e:
		import traceback
		traceback.print_exc()
		return{
			"error":str(e)
		}

# ============================================================
# Uruchamianie:
# uvicorn test_zdjecie_api:app --host 0.0.0.0 --port 8000
# ============================================================
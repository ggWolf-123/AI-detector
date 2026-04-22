import cv2
from models.image_model import predict_frame_local

def analyze_video(video_path: str, frame_step: int):
    if frame_step < 1:
        frame_step = 1
    cap=cv2.VideoCapture(video_path)

    if not cap.isOpened():
        return -1

    current_frame=0
    analyzed=0
    ai_count=0

    while True:
        ret, frame=cap.read()
        if not ret:
            break
        if current_frame % frame_step == 0:
            result=predict_frame_local(frame)
            if result==1:
                ai_count+=1
            analyzed+=1
        current_frame+=1

    cap.release()
    if analyzed == 0:
        return 0
    return (ai_count / analyzed)*100
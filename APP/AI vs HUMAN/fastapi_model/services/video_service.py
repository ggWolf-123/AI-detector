import cv2
from models.image_model import predict_frame_local

def analyze_video(video_path: str, frame_step: int):
    """
    Analyze a video to determine the percentage of frames that are AI-generated. The function takes a video file path as input, processes the video frame by frame using the loaded image classification model, and calculates the percentage of frames predicted to be AI-generated.

    Args:
        video_path: A string containing the path to the video file that needs to be analyzed.
        frame_step: An integer specifying the step size for frame sampling. Only every nth frame will be analyzed.

    Returns:
        float: The percentage of frames predicted to be AI-generated.
    """
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
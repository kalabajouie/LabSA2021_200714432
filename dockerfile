FROM python:3

WORKDIR /usr/src/app

COPY requirements.txt ./
COPY holamundo.py ./

RUN pip install --no-cache-dir -r requirements.txt

COPY . .

CMD [ "python", "./holamundo.py" ]
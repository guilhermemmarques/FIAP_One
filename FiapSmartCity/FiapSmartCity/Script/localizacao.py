import csv
from geopy import GoogleV3
import pandas as pds

df = pds.read_csv("../../../../../Properties/converter.csv", encoding='UTF8')

geolocator = GoogleV3(api_key="AIzaSyBlK_WTi2NnoLIL-daBjPpRFjY0cn0aW5A")
location = geolocator.geocode(df["endereço"])

print(location.raw)

coordenadas = (location.latitude, location.longitude)
print(coordenadas)

saida = open("../../../../../Properties/coordenadas.csv", 'w', newline='')
escrever = csv.writer(saida)
escrever.writerow(coordenadas)
saida.close()

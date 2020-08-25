
import requests
url = 'https://raw.githubusercontent.com/AlexFitzgerald/Marsh-COVID-19-Protocols/master/Marsh_Temperature_Screening/Marsh_Temperature_Screening/temperature.js'
r = requests.get(url, allow_redirects=True)
open('/home/pi/temperature.js', 'wb').write(r.content)
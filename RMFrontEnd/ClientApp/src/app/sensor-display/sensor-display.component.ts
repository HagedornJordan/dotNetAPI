import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-sensor-display',
  templateUrl: './sensor-display.component.html',
  styles: ['table, th, td {border: 1px solid black; border-collapse: collapse;}']
})

export class SensorDisplayComponent {

  public dataPoints: SensorData[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SensorData[]>("http://localhost:4200/api/" + 'SensorReadings', requestOptions).subscribe(result => {
      this.dataPoints = result;
      console.log("l")
      console.log(result)
    }, error => console.error(error));
  }
}

interface SensorData {
  date: string;
  temperatureC: number;
}

const headerDict = {
  'Content-Type': 'application/json',
  'Accept': 'application/json',
  'Access-Control-Allow-Headers': 'Content-Type',
}

const requestOptions = {
  headers: new HttpHeaders(headerDict),
};

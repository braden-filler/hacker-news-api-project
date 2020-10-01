import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: any[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, ) {
   // http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
     // this.forecasts = result;
    //}, error => console.error(error));

    //http.get<number[]>('https://localhost:44358/api/values').subscribe(result => {
      //this.forecasts = result;
      //console.log('forcasts', this.forecasts)
      //http.get<any>('https://localhost:44358/api/values/' + this.forecasts[0]).subscribe(result => {
        //console.log(result);
      //})
    //}, error => console.error(error));

  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

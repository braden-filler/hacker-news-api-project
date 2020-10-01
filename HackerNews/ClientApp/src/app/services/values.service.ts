import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ValuesService {

  constructor(private _http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


  public getValues(pageSize: number, pageNum: number, search?: string) {
    console.log('search', search)
    let searchStr = '';
    if (search) {
      searchStr += '/' + search
    }
    return this._http.get('api/values/' + pageSize + '/' + pageNum + searchStr);
  }

  public getStory(id: number) {
    let uri = "?"
    //uri += "id=" + ids[0] + "";
    return this._http.get('api/values/' + id)
  }
}

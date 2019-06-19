import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataService {

  constructor(private http: HttpClient) { }

  getAddressAutocompleate(search : string) : any{   
    return this.http.get(`api/ApiData/GetAddressAutocompleate?search=${search}`);
  }

  getCoordinates(address: string): any {
    return this.http.get(`api/ApiData/GetCoordinates?address=${address}`);
  }
}

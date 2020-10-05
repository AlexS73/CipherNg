import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';

@Injectable()
export class HttpService{
    constructor(private http: HttpClient){ }
 
    getData(strForCipher : string)
    {
        return this.http.get('https://localhost:5001/api/cipher?strForCipher="' + strForCipher+'"');        
    }
}
import { Component, OnInit } from "@angular/core";
import { HttpService} from '../http.service';
import { EnctiptionLog } from "./EnctiptionLog";

@Component({
    selector: "CipherComponent",
    templateUrl: "./app.component.html",
    styleUrls: ['./app.style.css'],
    providers:[HttpService]
})
export class CipherComponent{
    recordForCipher:EnctiptionLog[] = [];
    inputText:string = "";
    cipherText:string = "";

    constructor(private httpService: HttpService){}

    GetCipher(inputText){
        this.httpService.getData(inputText).subscribe((data:string) => this.recordForCipher.push(new EnctiptionLog(data)));
    }
}


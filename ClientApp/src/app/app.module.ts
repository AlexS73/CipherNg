import { NgModule }      from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import { CipherComponent }   from './CipherForm/app.component';


@NgModule({
    imports:[BrowserModule, FormsModule,HttpClientModule],
    declarations:[CipherComponent],
    bootstrap:[CipherComponent]
})
export class AppModule{}

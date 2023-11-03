import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MatrixMultiplicationComponent } from './components/matrix-multiplication/matrix-multiplication.component';
import {FormsModule} from "@angular/forms";
import {MatrixService} from "./services/matrix.service";
import {HttpClientModule} from "@angular/common/http";

@NgModule({
  declarations: [
    AppComponent,
    MatrixMultiplicationComponent
  ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule
    ],
  providers: [
    MatrixService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

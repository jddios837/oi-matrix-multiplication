import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class MatrixService {
  private apiUrl = 'http://localhost:5261/matrix/multiply';

  constructor(private http: HttpClient) {}

  sendMatrixData(data: { matrixA: number[][], matrixB: number[][] }) {
    return this.http.post(this.apiUrl, data);
  }

}

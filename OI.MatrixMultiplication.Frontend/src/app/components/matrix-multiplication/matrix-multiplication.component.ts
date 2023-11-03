import { Component } from '@angular/core';
import {MatrixService} from "../../services/matrix.service";

@Component({
  selector: 'app-matrix-multiplication',
  templateUrl: './matrix-multiplication.component.html',
  styleUrls: ['./matrix-multiplication.component.scss'],
})
export class MatrixMultiplicationComponent {
  matrixARows: number = 2;
  matrixAColumns: number = 2;
  matrixBRows: number = 2;
  matrixBColumns: number = 2;
  matrixDimensions: number[] = [1, 2, 3, 4, 5];
  matrixA: number[][] = this.initializeMatrix(this.matrixARows, this.matrixAColumns);
  matrixB: number[][] = this.initializeMatrix(this.matrixBRows, this.matrixBColumns);
  result: number[][] = [];

  constructor(private matrixService: MatrixService) {
  }

  initializeMatrix(rows: number, columns: number): number[][] {
    let matrix: number[][] = [];
    for (let i = 0; i < rows; i++) {
      matrix[i] = [];
      for (let j = 0; j < columns; j++) {
        matrix[i][j] = 0;
      }
    }
    return matrix;
  }

  multiplyMatrices() {
    console.log("multiplyMatrices()")
    // Send the data to the server
    this.matrixService.sendMatrixData({ matrixA: this.matrixA, matrixB: this.matrixB })
      .subscribe((response) => {
        // Handle the response from the server
        console.log(response);
      });
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Producto {
  id: number;
  nombre: string;
  precio: number;
  stockActual: number;
  stockMinimo: number;
  categoriaNombre: string;
}

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  private apiUrl = 'https://localhost:7265/api/inventory';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.apiUrl);
  }

  getLowStock(): Observable<Producto[]> {
    return this.http.get<Producto[]>(`${this.apiUrl}/low-stock`);
  }

  createOrder(order: any): Observable<any> {
    return this.http.post('https://localhost:7265/api/orders', order);
  }

}

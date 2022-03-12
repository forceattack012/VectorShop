import { Injectable } from '@angular/core';
import { HttpClient }  from '@angular/common/http';
import { Product } from '../shared/models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CatalogService {

  constructor(private httpClient: HttpClient) { }

  getAllProduct(): Observable<Product[]>  {
    return this.httpClient.get<Product[]>('/api/products');
  }

  getProductById(id: string| null): Observable<Product> {
    return this.httpClient.get<Product>(`/api/product/${id}`)
  }
}

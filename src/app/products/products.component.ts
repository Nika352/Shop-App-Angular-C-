import { Component, OnInit } from '@angular/core';
import { Product } from '../product';
import { ProductService } from '../product.service';
import { Observable, map } from 'rxjs';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit{
  products: Product[] = [];
  jsonString : string;

  constructor(private ProductService : ProductService) {
    this.jsonString = '';
   }

  ngOnInit(): void{
      this.getProductsJson();
  }

  getProducts():Observable<string>{
    
    return this.ProductService.getProducts().pipe(
      map(data => JSON.stringify(data))
    );
  }

  getProductsJson() : void{
    this.getProducts().subscribe(jsonString => {
      this.jsonString=jsonString;
      this.products = JSON.parse(this.jsonString);
    });
  }

  
}

import { Component, DoCheck, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { FullProduct } from 'src/app/types/Product/full-product-dto';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent implements OnInit, DoCheck {
  product: null | FullProduct = null;
  productRating: number = 0;
  productCategory: string = '';
  sizesOptions: any[] = [
    { label: 'Small', value: 'small' },
    { label: 'Medium', value: 'medium' },
    { label: 'Large', value: 'large' },
  ];
  selectedSizeIndex: number = 0;
  testValue: string = 'small';
  constructor(
    private activeRoute: ActivatedRoute,
    private productService: ProductService
  ) {}
  ngOnInit(): void {
    this.getProduct();

    console.log(`rating: ${this.productRating}`);
  }
  ngDoCheck(): void {
    if (this.product != null) {
      this.productRating = this.product.rate;
      this.productCategory = this.product.type;
    }
  }

  getProduct() {
    let urlProductId = this.activeRoute.snapshot.paramMap.get('id');
    if (urlProductId) {
      let productId = parseInt(urlProductId);
      this.productService.getProduct(productId).subscribe(
        (data) => {
          this.product = data;
        },
        (error) => {
          console.log(`error: ${error}`);
        }
      );
    }
  }
}

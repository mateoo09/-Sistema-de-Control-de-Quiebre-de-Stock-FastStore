import { Component, OnInit } from '@angular/core';
import { CommonModule, NgFor, NgClass } from '@angular/common';
import { InventoryService, Producto } from '../../services/inventory.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-inventory',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './inventory.component.html',
  styleUrl: './inventory.component.css'
})
export class InventoryComponent implements OnInit {

  productos: Producto[] = [];
  productoId: number | null = null;
  cantidad: number | null = null;
  mensaje: string = '';
  totalProductos: number = 0;
  productosBajoStock: number = 0;

  constructor(private inventoryService: InventoryService) { }

  ngOnInit(): void {
    this.loadProductos();
  }

  loadProductos(): void {
    this.inventoryService.getAll().subscribe(data => {
      this.productos = data;
      this.totalProductos = data.length;
      this.productosBajoStock = data.filter(
        p => p.stockActual < p.stockMinimo
      ).length;
    });
  }

  loadLowStock(): void {
    this.inventoryService.getLowStock().subscribe({
      next: (data) => {
        this.productos = data;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

  crearOrden(): void {
    if (!this.productoId || !this.cantidad) {
      alert('Datos inválidos');
      return;
    }

    const order = {
      productoId: this.productoId,
      cantidad: this.cantidad
    };

    this.inventoryService.createOrder(order).subscribe({
      next: () => {
        alert('Orden creada correctamente');
        this.mensaje = 'Orden creada correctamente';

        setTimeout(() => {
          this.mensaje = '';
        }, 3000);
      },
      error: (err) => {
        console.error(err);   
        alert('Error creando orden');
      }
    });
  }

  prepararOrden(producto: Producto): void {
    this.productoId = producto.id;
    const sugerido = producto.stockMinimo - producto.stockActual;
    this.cantidad = sugerido > 0 ? sugerido : 1;
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }

}

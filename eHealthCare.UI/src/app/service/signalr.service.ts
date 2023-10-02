import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../environments/environment';
import { ProductService } from '../modules/product/product.service';
import { Notification } from '../model/notification';


@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  private hubConnection!: signalR.HubConnection;
  constructor(private toastr: ToastrService, public productService: ProductService) { }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder().configureLogging(signalR.LogLevel.Information).withUrl(environment.baseUrl + "notify",
      {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
      }
    ).build();

    this.hubConnection.start().then(() => console.log('Connection started')).catch(err => console.log('Error while starting connection: ' + err))
  }

  public addProductListener = () => {
    this.hubConnection.on('BroadcastMessage', (notification: Notification) => {
      this.showNotification(notification);
      this.productService.getProducts();
    });
  }

  showNotification(notification: Notification) {
    this.toastr.warning(notification.description, notification.title);
  }
}

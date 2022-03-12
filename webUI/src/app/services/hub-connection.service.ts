import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class HubConnectionService {

  private hubConnection: signalR.HubConnection | undefined;

  constructor() {
  }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('ws://localhost:7000/gateway/basketHub', {
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    })
    .build();

    this.hubConnection
    .start()
    .then(() => console.log('connection started'))
    .catch(err => console.log('Error start connection hub ' + err));

    return this.hubConnection;
  }
}

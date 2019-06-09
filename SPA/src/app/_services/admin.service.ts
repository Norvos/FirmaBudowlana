import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Worker } from '../_models/worker';
import { Team } from '../_models/team';
import { Order } from '../_models/order';
import { Payment } from '../_models/payment';



@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl: any = 'http://localhost:5000/';

  constructor(private httpClient: HttpClient) { }

  getWorkers(): Observable<Worker[]> {
    return this.httpClient.get<Worker[]>(this.baseUrl + 'comparison/workers');
  }

  getUnpaidPayments(): Observable<Order[]> {
    return this.httpClient.get<Order[]>(this.baseUrl + 'add/payment')
  }

  getPaidPayments(): Observable<Payment[]> {
    return this.httpClient.get<Payment[]>(this.baseUrl + 'comparison/payments');
  }

  addPayment(order: Order) {
    return this.httpClient.post(this.baseUrl + 'add/payment', order);
  }

  addNewWorker(worker: Worker) {
    return this.httpClient.post(this.baseUrl + 'add/worker', worker);
  }

  addNewTeam(team: Team) {
    return this.httpClient.post(this.baseUrl + 'add/team', team);
  }

  validateOrder(order: Order) {
    return this.httpClient.post(this.baseUrl + 'order/validate', order);
  }

  getTeams(): Observable<Team[]> {
    return this.httpClient.get<Team[]>(this.baseUrl + 'comparison/teams');
  }

  getUnvalidatedOrders(): Observable<Order[]> {
    return this.httpClient.get<Order[]>(this.baseUrl + 'order/showInvalidated');
  }

  getAllOrders(): Observable<Order[]> {
    return this.httpClient.get<Order[]>(this.baseUrl + 'comparison/orders');
  }

  getOrder(id: string): Observable<Order> {
    return this.httpClient.get<Order>(this.baseUrl + 'order/validate/' + id);
  }
}

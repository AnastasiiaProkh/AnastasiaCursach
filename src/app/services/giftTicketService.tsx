import http from "../http-common";
import { TGiftTicket, TTicketType } from "../types";

class giftTicketService {
  getAll() {
    return http.get<Array<TGiftTicket>>("/GiftTicket");
  }

  create(data: TGiftTicket) {
    return http.post<Array<TGiftTicket>>("/GiftTicket", data);
  }
  delete(id: number) {
    return http.delete<Array<TGiftTicket>>(`/GiftTicket/${id}`);
  }
  update(data: TGiftTicket) {
    return http.put<Array<TGiftTicket>>("/GiftTicket", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new giftTicketService();

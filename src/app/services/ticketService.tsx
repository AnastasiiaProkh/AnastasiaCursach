import http from "../http-common";
import { TTicket } from "../types";

class ticketService {
  getAll() {
    return http.get<Array<TTicket>>("/Ticket");
  }

  create(data: TTicket) {
    return http.post<Array<TTicket>>("/Ticket", data);
  }
  delete(id: number) {
    return http.delete<Array<TTicket>>(`/Ticket/${id}`);
  }
  update(data: TTicket) {
    return http.put<Array<TTicket>>("/Ticket", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new ticketService();

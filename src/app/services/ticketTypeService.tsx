import http from "../http-common";
import { TTicketType } from "../types";

class ticketTypesService {
  getAll() {
    return http.get<Array<TTicketType>>("/TicketTypes");
  }

  create(data: TTicketType) {
    return http.post<Array<TTicketType>>("/TicketTypes", data);
  }
  delete(id: number) {
    return http.delete<Array<TTicketType>>(`/TicketTypes/${id}`);
  }
  update(data: TTicketType) {
    return http.put<Array<TTicketType>>("/TicketTypes", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new ticketTypesService();

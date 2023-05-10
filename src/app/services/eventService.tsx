import http from "../http-common";
import { TEvent, TTicketType } from "../types";

class eventService {
  getAll() {
    return http.get<Array<TEvent>>("/Event");
  }

  create(data: TEvent) {
    return http.post<Array<TEvent>>("/Event", data);
  }
  delete(id: number) {
    return http.delete<Array<TEvent>>(`/Event/${id}`);
  }
  update(data: TEvent) {
    return http.put<Array<TEvent>>("/Event", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new eventService();

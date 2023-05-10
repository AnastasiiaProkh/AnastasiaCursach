import http from "../http-common";
import { TEventType } from "../types";

class eventTypesService {
  getAll() {
    return http.get<Array<TEventType>>("/EventType");
  }

  create(data: TEventType) {
    return http.post<Array<TEventType>>("/EventType", data);
  }
  delete(id: number) {
    return http.delete<Array<TEventType>>(`/EventType/${id}`);
  }
  update(data: TEventType) {
    return http.put<Array<TEventType>>("/EventType", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new eventTypesService();

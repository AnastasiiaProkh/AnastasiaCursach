import http from "../http-common";
import { TRescheduled, TTicketType } from "../types";

class rescheduledService {
  getAll() {
    return http.get<Array<TRescheduled>>("/Rescheduled");
  }

  create(data: TRescheduled) {
    return http.post<Array<TRescheduled>>("/Rescheduled", data);
  }
  delete(id: number) {
    return http.delete<Array<TRescheduled>>(`/Rescheduled/${id}`);
  }
  update(data: TRescheduled) {
    return http.put<Array<TRescheduled>>("/Rescheduled", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new rescheduledService();

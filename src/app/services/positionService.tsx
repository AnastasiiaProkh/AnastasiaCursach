import http from "../http-common";
import { TPosition, TStaff } from "../types";

class StaffService {
  getAll() {
    return http.get<Array<TPosition>>("/Position");
  }
  addPosition(data: TPosition) {
    return http.post<Array<TPosition>>("/Position", data);
  }
  deletePosition(id: number) {
    return http.delete<Array<TPosition>>(`/Position/${id}`);
  }
  updatePosition(data: TPosition) {
    return http.put<Array<TPosition>>(`/Position`, data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new StaffService();

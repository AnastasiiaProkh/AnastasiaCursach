import http from "../http-common";
import { TStaff } from "../types";

class StaffService {
  getAll() {
    return http.get<Array<TStaff>>("/Staff");
  }

  create(data: TStaff) {
    return http.post<Array<TStaff>>("/Staff", data);
  }
  delete(id: number) {
    return http.delete<Array<TStaff>>(`/Staff/${id}`);
  }
  update(data: TStaff) {
    return http.put<Array<TStaff>>("/Staff", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new StaffService();

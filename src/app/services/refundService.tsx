import http from "../http-common";
import { TRefund, TTicketType } from "../types";

class refundService {
  getAll() {
    return http.get<Array<TRefund>>("/Refund");
  }

  create(data: TRefund) {
    return http.post<Array<TRefund>>("/Refund", data);
  }
  delete(id: number) {
    return http.delete<Array<TRefund>>(`/Refund/${id}`);
  }
  update(data: TRefund) {
    return http.put<Array<TRefund>>("/Refund", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new refundService();

import http from "../http-common";
import { TInvitations } from "../types";

class invitationsService {
  getAll() {
    return http.get<Array<TInvitations>>("/Invitations");
  }

  create(data: TInvitations) {
    return http.post<Array<TInvitations>>("/Invitations", data);
  }
  delete(id: number) {
    return http.delete<Array<TInvitations>>(`/Invitations/${id}`);
  }
  update(data: TInvitations) {
    return http.put<Array<TInvitations>>("/Invitations", data);
  }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new invitationsService();

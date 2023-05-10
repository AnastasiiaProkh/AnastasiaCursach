import { useState } from "react";
import MyTable from "../reusable/MyTable";
import invitationsService from "../services/invitationsService";
import { TInvitations } from "../types";

const Invitations = (): JSX.Element => {
  const [invitations, setInvitations] = useState<TInvitations[]>([]);

  useState(() => {
    invitationsService.getAll().then(({ data }) => {
      setInvitations(data);
    });
  });

  return (
    <>
      {invitations.length > 0 && (
        <MyTable
          data={invitations}
          onDeleteClick={(value) => {
            invitationsService.delete(value.id).then(({ data }) => {
              setInvitations(data);
            });
          }}
          onEditClick={() => {}}
        />
      )}
    </>
  );
};

export default Invitations;

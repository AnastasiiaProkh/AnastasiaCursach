import { useState } from "react";
import MyTable from "../reusable/MyTable";
import sponsorsService from "../services/sponsorsService";
import { TSponsors } from "../types";

const Sponsors = (): JSX.Element => {
  const [sponsors, setSponsors] = useState<TSponsors[]>([]);

  useState(() => {
    sponsorsService.getAll().then(({ data }) => {
      setSponsors(data);
    });
  });

  return (
    <>
      {sponsors.length > 0 && (
        <MyTable
          data={sponsors}
          onDeleteClick={(value) => {
            sponsorsService.delete(value.id).then(({ data }) => {
              setSponsors(data);
            });
          }}
          onEditClick={() => {}}
        />
      )}
    </>
  );
};

export default Sponsors;

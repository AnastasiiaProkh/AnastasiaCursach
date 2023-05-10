import { nanoid } from "nanoid";
import { Button, Table } from "reactstrap";

interface Props<T> {
  data: T[];
  onEditClick: (args: T) => void;
  onDeleteClick: (args: T) => void;
}

const MyTable = <T extends unknown>({
  data,
  onEditClick,
  onDeleteClick,
}: Props<T>): JSX.Element => {
  return (
    <Table bordered striped dark>
      <thead>
        <tr>
          {Object.keys(data[0] as object).map((key) => (
            <th key={key}>{key}</th>
          ))}
        </tr>
      </thead>
      <tbody>
        {data.map((member: any) => (
          <tr key={member.id}>
            {Object.keys(member).map((e) => (
              <td key={nanoid()}>
                {member[e as keyof (typeof data)[0]]?.toString()}
              </td>
            ))}
            <td>
              <Button onClick={() => onEditClick(member)}>Edit</Button>
            </td>
            <td>
              <Button onClick={() => onDeleteClick(member)}>Delete</Button>
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
};

export default MyTable;

import { useFormik } from "formik";
import React, { useEffect, useState } from "react";
import { Button, Col, Modal, ModalBody, ModalHeader, Row } from "reactstrap";
import MyTable from "../reusable/MyTable";
import positionService from "../services/positionService";
import { TPosition } from "../types";

const Positions = (): JSX.Element => {
  const [positions, setPositions] = useState<TPosition[]>([]);
  const [addModalOpen, setAddModalOpen] = useState<boolean>(false);

  useEffect(() => {
    positionService.getAll().then(({ data }) => setPositions(data));
  }, []);

  const formik = useFormik<TPosition>({
    initialValues: { id: 0, name: "" },
    onSubmit: (values) => {
      if (values.id === 0)
        positionService
          .addPosition(values)
          .then(({ data }) => setPositions(data));
      else
        positionService.updatePosition(values).then(({ data }) => {
          setPositions(data);
        });
      setAddModalOpen(false);
    },
  });

  return (
    <>
      <Button onClick={() => setAddModalOpen(true)} className="w-100">
        Add record
      </Button>
      {positions.length > 0 && (
        <MyTable
          data={positions}
          onDeleteClick={(value) =>
            positionService
              .deletePosition(value.id)
              .then(({ data }) => setPositions(data))
          }
          onEditClick={(value) => {
            formik.setValues({ ...value });
            setAddModalOpen(true);
          }}
        />
      )}
      {addModalOpen && (
        <Modal isOpen={addModalOpen} className="text-dark">
          <ModalHeader>
            {formik.values.id > 0 ? "Edit position" : "Create position"}
          </ModalHeader>
          <ModalBody>
            <form onSubmit={formik.handleSubmit}>
              <Row>
                <Col>
                  <label htmlFor="name" className="mb-2">
                    Position name
                  </label>
                  <input
                    id="name"
                    name="name"
                    onChange={formik.handleChange}
                    value={formik.values.name}
                    className="form-control"
                  ></input>
                </Col>
              </Row>
              <Row className="mt-4">
                <Col>
                  <Button type="submit">Submit</Button>
                </Col>
                <Col className="justify-content-end d-flex">
                  <Button
                    color="secondary"
                    onClick={() => setAddModalOpen(false)}
                  >
                    Cancel
                  </Button>
                </Col>
              </Row>
            </form>
          </ModalBody>
        </Modal>
      )}
    </>
  );
};

export default Positions;

import { useFormik } from "formik";
import moment from "moment";
import React, { useEffect, useState } from "react";
import { Button, Modal, ModalBody, ModalHeader, Row, Col } from "reactstrap";
import MyTable from "../reusable/MyTable";
import positionService from "../services/positionService";
import staffService from "../services/staffService";
import { TPosition, TStaff } from "../types";

// Easiest way to declare a Function Component; return type is inferred.
const Staff = (): JSX.Element => {
  const [staff, setStaff] = useState<TStaff[]>([]);
  const [addModalOpen, setAddModalOpen] = useState<boolean>(false);
  const [positions, setPositions] = useState<TPosition[]>([]);

  useEffect(() => {
    staffService.getAll().then(({ data }) => {
      setStaff(data as TStaff[]);
    });
    positionService.getAll().then(({ data }) => {
      setPositions(data);
    });
  }, []);

  const formik = useFormik<TStaff>({
    initialValues: {
      id: 0,
      stName: "",
      stBirthDate: "",
      stComm: 0,
      stContacts: "",
      stBankAccountNumber: "",
      positionId: 0,
    },
    onSubmit: (values) => {
      if (values.id > 0)
        staffService.update(values).then(({ data }) => {
          setStaff(data);
        });
      else
        staffService.create(values).then(({ data }) => {
          setStaff(data);
        });
      setAddModalOpen(false);
    },
  });

  return (
    <>
      <Button onClick={() => setAddModalOpen(true)} className="w-100">
        Add record
      </Button>
      {staff.length > 0 && (
        <MyTable
          data={staff}
          onEditClick={(value) => {
            formik.setValues({ ...value });
            setAddModalOpen(true);
          }}
          onDeleteClick={(value) =>
            staffService.delete(value.id).then(({ data }) => {
              setStaff(data);
            })
          }
        />
      )}
      {staff.length > 0 && (
        <Modal isOpen={addModalOpen} className="text-dark">
          <ModalHeader>
            {formik.values.id > 0 ? "Edit staff" : "Create staff"}
          </ModalHeader>
          <ModalBody>
            <form onSubmit={formik.handleSubmit}>
              <Row>
                <Col>
                  <label htmlFor="stName" className="mb-2">
                    Name
                  </label>
                  <input
                    id="stName"
                    name="stName"
                    onChange={formik.handleChange}
                    value={formik.values.stName}
                    className="form-control"
                  ></input>
                </Col>
              </Row>
              <Row>
                <Col>
                  <label htmlFor="stBirthDate" className="mb-2">
                    Birth date
                  </label>
                  <input
                    id="stBirthDate"
                    name="stBirthDate"
                    onChange={formik.handleChange}
                    value={moment(formik.values.stBirthDate).format(
                      "YYYY-MM-DD"
                    )}
                    className="form-control"
                    type="date"
                  ></input>
                </Col>
              </Row>
              <Row>
                <Col>
                  <label htmlFor="stComm" className="mb-2">
                    Comm
                  </label>
                  <input
                    id="stComm"
                    name="stComm"
                    onChange={formik.handleChange}
                    value={formik.values.stComm.toString()}
                    className="form-control"
                    type="number"
                  ></input>
                </Col>
              </Row>
              <Row>
                <Col>
                  <label htmlFor="stContacts" className="mb-2">
                    Contact
                  </label>
                  <input
                    id="stContacts"
                    name="stContacts"
                    onChange={formik.handleChange}
                    value={formik.values.stContacts}
                    className="form-control"
                  ></input>
                </Col>
              </Row>
              <Row>
                <Col>
                  <label htmlFor="stBankAccountNumber" className="mb-2">
                    Bank Account number
                  </label>
                  <input
                    id="stBankAccountNumber"
                    name="stBankAccountNumber"
                    onChange={formik.handleChange}
                    value={formik.values.stBankAccountNumber}
                    className="form-control"
                  ></input>
                </Col>
              </Row>
              <Row>
                <Col>
                  <label htmlFor="stName" className="mb-2">
                    Position
                  </label>
                  <select
                    id="positionId"
                    name="positionId"
                    onChange={formik.handleChange}
                    value={formik.values.positionId}
                    className="form-control"
                  >
                    {positions.map((pos) => {
                      return (
                        <option value={pos.id} key={pos.id}>
                          {pos.name}
                        </option>
                      );
                    })}
                  </select>
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
export default Staff;

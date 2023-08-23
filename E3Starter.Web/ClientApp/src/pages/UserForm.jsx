import React from "react";
import AdminLayout from "../layouts/AdminLayout";
import { Form, FormGroup, Label, Input } from "reactstrap";

function UserForm() {
  return (
    <AdminLayout>
      <h2>Create User</h2>
      <Form>
        <FormGroup>
          <Label for="username">Username</Label>
          <Input
            id="username"
            name="username"
            placeholder="Username"
            type="email"
          />
        </FormGroup>
        <FormGroup>
          <Label for="username">Email</Label>
          <Input
            id="email"
            name="email"
            placeholder="Email"
            type="email"
          />
        </FormGroup>
      </Form>
    </AdminLayout>
  );
}

export default UserForm;

import React from 'react';
import { useField } from "formik";
import DatePicker from "react-datepicker";

const DateField = ({ name="" }) => {
  const [field, meta, helpers] = useField(name);

  const { value } = meta;
  const { setValue } = helpers;

  return (
    <DatePicker
      dateFormat="dd.MM.yyyy"
      placeholderText="31.12.2000"
      {...field}
      selected={value}
      onChange={(date) => setValue(date)}
    />
  );
};

export default DateField;
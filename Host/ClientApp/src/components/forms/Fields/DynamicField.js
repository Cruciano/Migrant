import React from 'react';

import { Field } from "formik";
import DateField from "./DateField";
import SelectRowField from "./SelectRowField";
import styles from './Fields.module.scss';

const FieldType = {
  "text": Field,
  "date": DateField,
  "selectRow": SelectRowField,
}

const DynamicField = ({ type, title, style, ...rest }) => {
  return (
    <div className={styles.block} style={style}>
      <p>{title}</p>
      {React.createElement(FieldType[type], {...rest})}
    </div>
  );
};

export default DynamicField;
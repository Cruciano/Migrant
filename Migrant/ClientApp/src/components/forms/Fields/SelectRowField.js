import React, {useEffect} from 'react';
import { useField } from "formik";
import styles from './Fields.module.scss';

const SelectRowField = ({ name, options, width='100%' }) => {
  const [, meta, helpers] = useField(name);

  const { value } = meta;
  const { setValue } = helpers;

  useEffect(() => {
    if (options.length > 0) {
      setValue(options[0].value).then();
    }
  }, []);

  return (
    <div
      className={styles.wrapper}
      style={{
        width: width,
      }}
    >
      {options.map(option => (
        <div
          className={`${styles.element} ${value === option.value ? styles.active : ''}`}
          onClick={() => setValue(option.value)}
        >
          {option.title}
        </div>
      ))}
    </div>
  );
};

export default SelectRowField;
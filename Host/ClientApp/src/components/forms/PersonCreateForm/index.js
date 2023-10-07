import React from 'react';
import * as Yup from "yup";
import { Form, Formik, Field } from "formik";
import styles from './PersonCreateForm.module.scss';
import "react-datepicker/dist/react-datepicker.css";
import DynamicField from "../Fields/DynamicField";

const initForm = {
  fullName: '',
  birthDate: '',
  gender: 'male',
  document: '',
  asIdpRegDate: '',
  regAddress: '',
  houseState: '',
  currAddress: '',
  needHouse: false,
  phone: '',
  invalidity: '',
  isLargeFamily: false,
  needHelp: false,
  additionalInfo: '',
  dismissalNote: false,
  regPlace: '',
};

const schema = Yup.object().shape({
  fullName: Yup.string(),
  birthDate: Yup.date(),
  gender: Yup.mixed().oneOf(['male', 'female']),
  document: Yup.string(),
  asIdpRegDate: Yup.date(),
  regAddress: Yup.string(),
  houseState: Yup.mixed().oneOf(['damaged', 'survived']),
  currAddress: Yup.string(),
  needHouse: Yup.boolean(),
  phone: Yup.string().matches(/^\+?[0-9]{3}-?[0-9]{6,12}$/),
  invalidity: Yup.mixed().oneOf(['no disability', '1 group', '2 group', '3 group', 'disabled child']),
  isLargeFamily: Yup.boolean(),
  needHelp: Yup.boolean(),
  additionalInfo: Yup.string(),
  dismissalNote: Yup.boolean(),
  regPlace: Yup.string(),
});

const genderOptions = [
  {title: 'Чоловік', value: 'male'},
  {title: 'Жінка', value: 'female'},
]

const invalidityOptions = [
  {title: 'Відсутня', value: 'no disability'},
  {title: 'І група', value: '1 group'},
  {title: 'ІІ група', value: '2 group'},
  {title: 'ІІІ група', value: '3 group'},
  {title: 'Дитина з інвалідністю', value: 'disabled child'},
];

const houseStateOptions = [
  {title: 'Пошкоджено', value: 'damaged'},
  {title: 'Вціліло', value: 'survived'},
];

const needHouseOptions = [
  {title: 'Не потребує', value: false},
  {title: 'Потребує', value: true},
];

const regPlaceOptions = [
  {title: 'Носівка ЦНАП', value: 'Носівка ЦНАП'},
  {title: 'Держанівка старостат', value: 'Держанівка старостат'},
  {title: 'Володькова дівиця', value: 'Володькова дівиця'},
  {title: 'Самостійно ДІЯ', value: 'Самостійно ДІЯ'},
  {title: 'Управління соціального захисту населення', value:'Управління соціального захисту населення'},
]

const PersonCreateForm = () => {
  const handleSubmit = (values) => {
    console.log('values:', values);
  };

  return (
    <Formik
      initialValues={initForm}
      validationSchema={schema}
      onSubmit={handleSubmit}
    >
      {({ values, submitForm }) => (
        <Form className={styles.form}>
          <DynamicField type="text" title="П. І. П." name="fullName" placeholder="Іваненко Іван Іванович" />
          <DynamicField type="date" title="Дата народження" name="birthDate" />
          <DynamicField type="selectRow" title="Стать" name="gender" options={genderOptions} width="50%" />
          <DynamicField type="text" title="Документ, що посвідчує особу" name="document" placeholder="xxxxx" />
          <DynamicField type="date" title="Дата реєстрації ВПО" name="asIdpRegDate" />
          <DynamicField type="text" title="Адреса реєстрації" name="regAddress" placeholder="xxxxx" />
          <DynamicField type="selectRow" title="Стан житла" name="houseState" options={houseStateOptions} width="70%" />
          <DynamicField type="text" title="Адреса проживання" name="currAddress" placeholder="xxxxx" />
          <DynamicField
            type="selectRow"
            title="Потреба в житлі"
            name="needHouse"
            options={needHouseOptions}
            width="80%"
          />
          <DynamicField type="text" title="Телефон" name="phone" placeholder="+380XX0000000" />
          <DynamicField
            type="selectRow"
            title="Інвалідність"
            style={{gridColumn: '1 / span 2'}}
            name="invalidity"
            options={invalidityOptions}
          />
          <p><label>Багатодітна сім'я: <Field type="checkbox" name="isLargeFamily" /></label></p>
          <p><label>Потребує допомоги: <Field type="checkbox" name="needHelp" /></label></p>
          <p><label>Відмітка про вибуття: <Field type="checkbox" name="dismissalNote" /></label></p>
          <DynamicField
            type="text"
            title="Додаткова інформація"
            style={{gridColumn: '1 / span 2'}}
            name="additionalInfo"
            placeholder="Додаткова інформація..."
            component="textarea"
          />
          <DynamicField
            type="selectRow"
            title="Місце проходження реєстрації"
            style={{gridColumn: '1 / span 2'}}
            name="regPlace"
            options={regPlaceOptions}
          />

          <button type="submit" className={styles.submitButton} onClick={submitForm}>
            Зберегти
          </button>
        </Form>
      )}
    </Formik>
  );
};

export default PersonCreateForm;
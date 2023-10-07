import React from 'react';
import Layout from "../../components/Layout";
import PersonCreateForm from "../../components/forms/PersonCreateForm";
import styles from "./PersonCreate.module.scss";

const PersonCreatePage = () => {
  return (
    <Layout>
      <div className={`shadow-container ${styles.wrapper}`}>
        <p className={styles.title}>Реєстрація та облік ВПО</p>
        <PersonCreateForm />
      </div>
    </Layout>
  );
}

export default PersonCreatePage;

import React from 'react';
import Layout from "../../components/Layout";
import BoxEmblem from '../../assets/images/helping_emblem.svg'

const AidPage = () => {
  return (
    <Layout aidMode>
      <div className="shadow-container wrapper">
        <p className="title">Видача гуманітарної допомоги ВПО</p>
        <p className="concerning">Програмний комлекс для обліку та реестрації внутрішньо переміщених осіб</p>
        <p className="common">Інформація про видачу допомоги</p>
        <ul className="list">
          <li>Кількість відкритих відомостей: 11</li>
          <li>Відомість про червоний хрест: 111</li>
          <li>Відомість додаткова: 1</li>
        </ul>
        <img className="page-icon" src={BoxEmblem} alt="application emblem" />
      </div>
    </Layout>
  );
};

export default AidPage;
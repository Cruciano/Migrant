import React from 'react';
import Layout from "../../components/Layout";
import AppIcon from "../../assets/images/app_emblem.svg";

const HomePage = () => {
  return (
    <Layout>
      <div className="shadow-container wrapper">
        <p className="title">Облік та реєстрація ВПО</p>
        <p className="concerning">Програмний комлекс для обліку та реестрації внутрішньо переміщених осіб</p>
        <p className="common">Узагальнена інформація про реєстр</p>
        <ul className="list">
          <li>Всього зареєстровано 111 внутрішньо переміщених осіб</li>
          <li>З них чоловіків: 111, жінок: 111</li>
          <li>Дітей до 6 років: 111</li>
          <li>Дітей від 6 до 17 років: 111</li>
          <li>Осіб похилого віку: 111</li>
          <li>Осіб, що мають інвалідність: 111</li>
          <li>Входять до складу багатодітних сімей: 111</li>
          <li>Вибуло за межі ОТГ: 111</li>
          <li>Особи, в яких пошкоджено житло: 111</li>
          <li>Мають потребу в житлі: 111</li>
          <li>Кількість осіб, що потребують допомоги: 111</li>
          <li>Загальна кількість потреб ВПО: 111</li>
        </ul>
        <img className="page-icon" src={AppIcon} alt="application emblem" />
      </div>
    </Layout>
  );
}

export default HomePage;

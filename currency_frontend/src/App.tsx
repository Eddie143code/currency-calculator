import { useState, useEffect } from "react";
import axios, { AxiosResponse } from "axios";
import CurrencyConvert from "./components/CurrencyConvert";
import TenMVCurrencies from "./components/TenMVCurrencies";
import currencyRates from "./components/data/rates.json";
import { Oval } from "react-loading-icons";

const postUrl: string = "http://localhost:5188/api/currencyapi" as string;

interface postType {
  baseCurrency: {
    item1: string;
    item2: number;
  };
  convertedCurrency: {
    item1: string;
    item2: number;
  };
  convertedAmount: number;
  currencyList: {
    item1: string;
    item2: number;
  }[];
}

function App() {
  const [currencies, setCurrencies] = useState<any>(currencyRates);
  const [postData, setPostData] = useState<postType>({
    baseCurrency: {
      item1: "",
      item2: 0,
    },
    convertedCurrency: {
      item1: "",
      item2: 0,
    },
    convertedAmount: 0,
    currencyList: [
      {
        item1: "",
        item2: 0,
      },
    ],
  });
  const [loading, setLoading] = useState<boolean>(false);

  const currencySubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setPostData({
      baseCurrency: {
        item1: "",
        item2: 0,
      },
      convertedCurrency: {
        item1: "",
        item2: 0,
      },
      convertedAmount: 0,
      currencyList: [
        {
          item1: "",
          item2: 0,
        },
      ],
    });
    setLoading(true);
    const response: AxiosResponse<postType> = await axios.post(
      postUrl,
      postData
    );
    const updatedData: postType = response.data;

    setPostData(updatedData);
    setLoading(false);
  };

  return (
    <div className="h-[100vh] bg-[#00214A]">
      <section className="flex flex-col justify-center items-center h-[90vh] ">
        <div className="flex flex-col rounded-lg min-h-[90vh] shadow-2xl p-2 gap-10 bg-[white]">
          <div className="flex justify-center items-center w-[100%] lg:mt-5 font-bold">
            <h1 className=" text-3xl p-2 text-[#00214A] lg:text-[3rem]">
              Currency Converter
            </h1>
          </div>
          <CurrencyConvert
            currencies={currencies}
            currencySubmit={currencySubmit}
            setPostData={setPostData}
            postData={postData}
          />
          {postData.currencyList[0].item1 !== "" &&
          postData.currencyList[0].item2 !== 0 ? (
            <TenMVCurrencies postData={postData} />
          ) : (
            loading && (
              <div className="flex justify-center">
                <Oval stroke="black" strokeOpacity={0.5} fill="white" />{" "}
              </div>
            )
          )}
        </div>
      </section>
    </div>
  );
}

export default App;

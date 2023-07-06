const TenMVCurrencies = ({ postData }: any) => {
  const currencyList = postData.currencyList;
  return (
    <article className="flex flex-col gap-10">
      <div className="flex justify-center text-center w-[100%]">
        <h1 className="text-xl lg:text-3xl">
          Most Valuable Currencies for{" "}
          <span className="text-[1.5rem]">
            {postData.convertedCurrency.item1}
          </span>
        </h1>
      </div>
      <div className="flex justify-center items-center  mb-10">
        <table className="w-[80%] ">
          <thead className="">
            <tr className="text-[1.3rem]">
              <th className="border-[1px] border-black w-[20%]">Ranking</th>
              <th className="border-[1px] border-black">Currency</th>
              <th className="border-[1px] border-black">Amount</th>
            </tr>
          </thead>

          <tbody className="text-[1.1rem]">
            {currencyList.map((currency: any, i: number) => {
              return (
                <tr key={currency.item1} className="">
                  <td className=" border-[1px] border-black">{i + 1}</td>
                  <td className=" border-[1px] border-black">
                    {currency.item1}
                  </td>
                  <td className="border-[1px] border-black">
                    {currency.item2}
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    </article>
  );
};

export default TenMVCurrencies;

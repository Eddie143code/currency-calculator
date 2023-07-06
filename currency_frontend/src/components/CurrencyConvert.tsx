const CurrencyConvert = ({
  currencies,
  currencySubmit,
  setPostData,
  postData,
}: any) => {
  const keys: Array<string> = Object.keys(currencies.rates);
  return (
    <article className="flex justify-center items-center">
      <form
        onSubmit={currencySubmit}
        className="flex flex-col justify-center items-center gap-5 h-[20vh] lg:flex-row lg:w-[80%]"
      >
        <div className="flex justify-center items-center gap-2">
          <select
            onChange={(e) =>
              setPostData((prevState: any) => ({
                ...prevState,
                baseCurrency: {
                  item1: e.target.value,
                  item2: Number(prevState.baseCurrency.item2),
                },
              }))
            }
            className=" border-[#71797E] border-[0.5px] text-[1.2rem] w-[20%] h-10  lg:w-[24%]"
          >
            <option>----</option>
            {keys.map((key) => (
              <option key={key} value={key}>
                {key}
              </option>
            ))}
          </select>
          <input
            placeholder="0"
            type="number"
            className="border-b-[1px] border-black text-[1.5rem] w-[50%] lg:w-[60%]"
            onChange={(e) =>
              setPostData((prevState: any) => ({
                ...prevState,
                baseCurrency: {
                  item1: prevState.baseCurrency.item1,
                  item2: Number(e.target.value),
                },
              }))
            }
          />
        </div>
        <div className="flex justify-center items-center gap-2">
          <select
            onChange={(e) =>
              setPostData((prevState: any) => ({
                ...prevState,
                convertedCurrency: {
                  item1: e.target.value,
                  item2: prevState.convertedCurrency.item2,
                },
              }))
            }
            className="border-[#71797E] border-[0.5px] text-[1.2rem] w-[20%] h-10 lg:w-[24%]"
          >
            <option>----</option>
            {keys.map((key) => (
              <option key={key} value={key}>
                {key}
              </option>
            ))}
          </select>
          <input
            type="number"
            className=" border-b-[1px] border-black  text-[1.5rem] w-[50%] bg-gray-200 lg:w-[60%]"
            readOnly
            value={postData.convertedAmount}
          />
        </div>
        <div className="flex justify-end w-[70%] lg:w-[20%]">
          <button
            type="submit"
            className="p-2 bg-[#0096FF] hover:bg-[#33ABFF] text-[white] rounded"
          >
            Submit
          </button>
        </div>
      </form>
    </article>
  );
};

export default CurrencyConvert;

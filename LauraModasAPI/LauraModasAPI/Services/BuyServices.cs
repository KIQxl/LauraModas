using AutoMapper;
using LauraModasAPI.Data;
using LauraModasAPI.Dtos.BuyDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace LauraModasAPI.Services
{
    public class BuyServices : IBuyServices
    {
        readonly DataContext _context;
        readonly IMapper _mapper;
        public BuyServices(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<List<ReadBuyDto>> GetBuys()
        {
            try
            {
                List<BuyModel> buys = await _context.Buys.ToListAsync();

                List<ReadBuyDto> buysView = _mapper.Map<List<ReadBuyDto>>(buys);

                return buysView;

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            
        }
        public async Task<ReadBuyDto> GetBuy(int id)
        {
            try
            {
                BuyModel buy = await _context.Buys.FirstOrDefaultAsync(b => b.Id.Equals(id));

                if (buy == null)
                {
                    throw new Exception("Compra não encontrada");
                }

                ReadBuyDto buyView = _mapper.Map<ReadBuyDto>(buy);

                return buyView;

            } catch (Exception ex) 
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<BuyModel> GetBuyModelForId(int id)
        {
            try
            {
                BuyModel buy = _context.Buys.FirstOrDefault(b => b.Id.Equals(id));

                if (buy == null) throw new Exception("Não encontrado");
                
                return buy;

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<ReadBuyDto>> GetBuysByName(string name)
        {
            try
            {

                List<BuyModel> buys = _context.Buys.Where(b => b.Name.ToUpper().Contains(name.ToUpper())).ToList();

                if (buys.Count == 0)
                {
                    throw new Exception($"Nenhuma compra corresponde a {name}");
                }

                List<ReadBuyDto> buysViews = _mapper.Map<List<ReadBuyDto>>(buys);

                return buysViews;

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


        public async Task<ReadBuyDto> PostBuy(CreateBuyDto request)
        {
            try
            {

                BuyModel buy = _mapper.Map<BuyModel>(request);

                _context.Buys.Add(buy);
                await _context.SaveChangesAsync();

                ReadBuyDto buyView = _mapper.Map<ReadBuyDto>(buy);

                return buyView;

            } catch (Exception ex) 
            {
                throw new Exception($"{ex.Message}");
            }

        }

        public async Task<ReadBuyDto> AlterBuy(int id, AlterBuyDto request)
        {
            try
            {
                BuyModel buy = await GetBuyModelForId(id);

                if(buy == null) throw new Exception($"Não foi possível encontrar a compra");
                
                buy.Name = request.Name;
                buy.Value = request.Value;
                buy.Description = request.Description;
                buy.Status = request.Status;

                await _context.SaveChangesAsync();

                ReadBuyDto buyView = _mapper.Map<ReadBuyDto>(buy);

                return buyView;

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> DeleteBuy(int id)
        {
            try
            {
                BuyModel buyDb = await GetBuyModelForId(id);

                if (buyDb != null)
                {
                    _context.Remove(buyDb);
                    _context.SaveChangesAsync();

                    return true;
                } else
                {
                    return false;
                }
            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


    }
}
